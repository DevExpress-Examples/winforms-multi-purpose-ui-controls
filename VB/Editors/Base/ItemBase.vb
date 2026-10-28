Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization
Imports System.Globalization
Imports DevExpress.XtraEditors

Namespace DevExpress.UITemplates.Collection.Editors

    Public MustInherit Class ItemBase
        Implements ICloneable
        Private _value As Object
        Private _caption As String
        Private _tag As Object
        Protected Sub New(value As Object, caption As String, tag As Object)
            _value = value
            _tag = tag
            _caption = If(caption, String.Empty)
        End Sub
        <ComponentModel.EditorAttribute(GetType(DevExpress.Utils.Editors.UIObjectEditor), GetType(System.Drawing.Design.UITypeEditor)), Category(CategoryName.Data)>
        Public Overridable Property Value As Object
            Get
                Return _value
            End Get
            Set(value As Object)
                If Me.Value Is value Then Return
                _value = value
                OnItemChanged()
            End Set
        End Property
        <Localizable(True), Category(CategoryName.Appearance)>
        Public Overridable Property Caption As String
            Get
                Return _caption
            End Get
            Set(value As String)
                If Equals(value, Nothing) Then value = String.Empty
                If Equals(Caption, value) Then Return
                _caption = value
                OnItemChanged()
            End Set
        End Property
        <DefaultValue(GetType(String), Nothing), ComponentModel.EditorAttribute(GetType(DevExpress.Utils.Editors.UIObjectEditor), GetType(System.Drawing.Design.UITypeEditor)), Category(CategoryName.Data)>
        Public Overridable Property Tag As Object
            Get
                Return _tag
            End Get
            Set(value As Object)
                _tag = value
            End Set
        End Property
        Private Function Clone1() As Object Implements ICloneable.Clone
            Return Clone()
        End Function
        Protected MustOverride Function Clone() As ItemBase
        Public Event Changed As EventHandler
        Protected Overridable Sub OnItemChanged()
            RaiseEvent Changed(Me, EventArgs.Empty)
        End Sub
        Public Overrides Function ToString() As String
            Return Caption
        End Function
        <ListBindable(False)>
        Public MustInherit Class Collection(Of TItem As ItemBase)
            Inherits CollectionBase
            Implements IEnumerable(Of TItem), INotifyCollectionChanged
            Public Event CollectionChanged As NotifyCollectionChangedEventHandler Implements INotifyCollectionChanged.CollectionChanged
            Default Public Property Item(index As Integer) As TItem
                Get
                    Return TryCast(List(index), TItem)
                End Get
                Set(value As TItem)
                    List(index) = value
                End Set
            End Property
            Public Function GetValues(selection As ICollection(Of TItem)) As HashSet(Of Object)
                Dim values As HashSet(Of Object) = New HashSet(Of Object)()
                For Each item As TItem In List
                    If selection.Contains(item) Then values.Add(item.Value)
                Next
                Return values
            End Function
            Public Function GetItemByValue(value As Object) As TItem
                For Each item As TItem In List
                    If Equals(value, item.Value) Then Return item
                Next
                Return Nothing
            End Function
            Public Function GetItemIndexByValue(value As Object) As Integer
                For i = 0 To Count - 1
                    Dim item = Me(i)
                    If Equals(value, item.Value) Then Return i
                Next
                Return -1
            End Function
            Public Overridable Sub Assign(collection As Collection(Of TItem))
                If collection Is Nothing Then Return
                BeginUpdate()
                Try
                    Clear()
                    For n = 0 To collection.Count - 1
                        Add(CType(collection(n).Clone(), TItem))
                    Next

                Finally
                    EndUpdate()
                End Try
            End Sub
            Public Sub AddEnum(enumType As Type, Optional addEnumeratorIntegerValues As Boolean = False, Optional displayTextConverter As Converter(Of Object, String) = Nothing)
                If displayTextConverter Is Nothing Then displayTextConverter = Function(x) EnumDisplayTextHelper.GetDisplayText(x)
                BeginUpdate()
                Try
                    Dim values = GetEnumValues(enumType)
                    For Each enumValue In values
                        Dim value = GetEnumValue(addEnumeratorIntegerValues, enumValue, enumType)
                        Add(CreateItem(value, displayTextConverter(enumValue)))
                    Next

                Finally
                    EndUpdate()
                End Try
            End Sub
            Public Sub AddEnum(Of TEnum)(Optional addEnumeratorIntegerValues As Boolean = False, Optional displayTextConverter As Converter(Of TEnum, String) = Nothing)
                If displayTextConverter Is Nothing Then displayTextConverter = Function(x) EnumDisplayTextHelper.GetDisplayText(x)
                BeginUpdate()
                Try
                    Dim values = GetEnumValues(GetType(TEnum))
                    For Each enumValue As TEnum In values
                        Dim value = GetEnumValue(addEnumeratorIntegerValues, enumValue, GetType(TEnum))
                        Add(CreateItem(value, displayTextConverter(enumValue)))
                    Next

                Finally
                    EndUpdate()
                End Try
            End Sub
            Private Shared Function GetEnumValues(enumType As Type) As Array
                enumType = If(Nullable.GetUnderlyingType(enumType), enumType)
                If enumType.IsEnum Then Return [Enum].GetValues(enumType)
                Return Array.CreateInstance(enumType, 0)
            End Function
            Private Shared Function GetEnumValue(addEnumeratorIntegerValues As Boolean, val As Object, enumType As Type) As Object
                If addEnumeratorIntegerValues Then
                    Dim enumValueType = [Enum].GetUnderlyingType(enumType)
                    Try
                        Return Convert.ChangeType(val, enumValueType)
                    Catch
                    End Try
                End If
                Return val
            End Function
            Public Overridable Sub AddRange(items As TItem())
                BeginUpdate()
                Try
                    For Each item As TItem In items
                        Add(item)
                    Next

                Finally
                    EndUpdate()
                End Try
            End Sub
            Public Overridable Sub Add(item As TItem)
                List.Add(item)
            End Sub
            Public Sub Add(value As Object, caption As String)
                List.Add(CreateItem(value, caption))
            End Sub
            Public Overridable Sub Insert(index As Integer, item As TItem)
                List.Insert(index, item)
            End Sub
            Public Overridable Sub Remove(item As TItem)
                List.Remove(item)
            End Sub
            Public Overridable Sub RemoveValue(value As Object)
                Dim hasRemoved = False
                BeginUpdate()
                Try
                    For i = Count - 1 To 0 Step -1
                        Dim item = Me(i)
                        If Equals(value, item.Value) Then
                            hasRemoved = True
                            List.RemoveAt(i)
                        End If
                    Next

                Finally
                    If hasRemoved Then
                        EndUpdate()
                    Else
                        CancelUpdate()
                    End If
                End Try
            End Sub
            Public Function IndexOf(item As TItem) As Integer
                Return List.IndexOf(item)
            End Function
            Private lockUpdate As Integer
            Public Overridable Sub BeginUpdate()
                lockUpdate += 1
            End Sub
            Public Overridable Sub EndUpdate()
                If Threading.Interlocked.Decrement(lockUpdate) = 0 Then RaiseCollectionChanged(ResetArgs)
            End Sub
            <EditorBrowsable(EditorBrowsableState.Advanced)>
            Public Overridable Sub CancelUpdate()
                lockUpdate -= 1
            End Sub
            Private ReadOnly Shared ResetArgs As NotifyCollectionChangedEventArgs = New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)
            Protected Overrides Sub OnInsertComplete(index As Integer, value As Object)
                Dim item As TItem = TryCast(value, TItem)
                AddHandler item.Changed, AddressOf OnItemChanged
                RaiseCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value))
            End Sub
            Protected Overrides Sub OnRemoveComplete(index As Integer, value As Object)
                Dim item As TItem = TryCast(value, TItem)
                RemoveHandler item.Changed, AddressOf OnItemChanged
                RaiseCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, value))
            End Sub
            Protected Overrides Sub OnSetComplete(index As Integer, oldValue As Object, newValue As Object)
                Dim item As TItem = TryCast(oldValue, TItem)
                RemoveHandler item.Changed, AddressOf OnItemChanged
                item = TryCast(newValue, TItem)
                AddHandler item.Changed, AddressOf OnItemChanged
                RaiseCollectionChanged(ResetArgs)
            End Sub
            Protected Overrides Sub OnClear()
                If Count = 0 Then Return
                BeginUpdate()
                Try
                    For n = Count - 1 To 0 Step -1
                        RemoveAt(n)
                    Next

                Finally
                    EndUpdate()
                End Try
            End Sub
            Protected Overrides Sub OnClearComplete()
                RaiseCollectionChanged(ResetArgs)
            End Sub
            Protected Overridable Sub OnItemChanged(sender As Object, e As EventArgs)
                RaiseCollectionChanged(ResetArgs)
            End Sub
            Protected Overridable Sub RaiseCollectionChanged(e As NotifyCollectionChangedEventArgs)
                If lockUpdate = 0 Then RaiseEvent CollectionChanged(Me, e)
            End Sub
            Private Shadows Iterator Function GetEnumerator() As IEnumerator(Of TItem) Implements IEnumerable(Of TItem).GetEnumerator
                For Each item As TItem In InnerList
                    Yield item
                Next
            End Function
            Protected MustOverride Function CreateItem(value As Object, caption As String) As TItem
        End Class
        <ListBindable(False)>
        Public Class Selection(Of TItem As ItemBase)
            Inherits HashSet(Of TItem)
            Implements ICollection(Of Object)
            Public Function ContainsValue(value As Object) As Boolean
                For Each item As TItem In Me
                    If Equals(item.Value, value) Then Return True
                Next
                Return False
            End Function
            Private ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of Object).IsReadOnly
                Get
                    Return CType(Me, ICollection(Of TItem)).IsReadOnly
                End Get
            End Property

            Private ReadOnly Property ICollection_Count As Integer Implements ICollection(Of Object).Count
                Get
                    Return Count
                End Get
            End Property

            Private Shadows Function Contains(item As Object) As Boolean Implements ICollection(Of Object).Contains
                If item Is Nothing Then Return False
                If Not TypeOf item Is TItem Then Return False
                Return MyBase.Contains(DirectCast(item, TItem))
            End Function
            Private Shadows Sub Add(item As Object) Implements ICollection(Of Object).Add
                If item IsNot Nothing AndAlso Not TypeOf item Is TItem Then Throw New ArgumentException("item")
                MyBase.Add(DirectCast(item, TItem))
            End Sub
            Private Shadows Function Remove(item As Object) As Boolean Implements ICollection(Of Object).Remove
                If item Is Nothing OrElse Not TypeOf item Is TItem Then Return False
                Return MyBase.Remove(DirectCast(item, TItem))
            End Function
            Private Shadows Sub CopyTo(array As Object(), arrayIndex As Integer) Implements ICollection(Of Object).CopyTo
                Dim selectedItems = New TItem(Count - arrayIndex - 1) {}
                MyBase.CopyTo(selectedItems, 0, selectedItems.Length)
                System.Array.Copy(selectedItems, 0, array, arrayIndex, selectedItems.Length)
            End Sub
            Private Shadows Function GetEnumerator() As IEnumerator(Of Object) Implements IEnumerable(Of Object).GetEnumerator
                Return MyBase.GetEnumerator()
            End Function

            Private Sub ICollection_Clear() Implements ICollection(Of Object).Clear
                Clear()
            End Sub
        End Class
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public MustInherit Class Converter(Of TItem As ItemBase)
            Inherits ExpandableObjectConverter
            Public Overrides Function CanConvertTo(context As ITypeDescriptorContext, destinationType As Type) As Boolean
                If destinationType Is GetType(InstanceDescriptor) Then Return True
                Return MyBase.CanConvertTo(context, destinationType)
            End Function
            Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As CultureInfo, value As Object, destinationType As Type) As Object
                If destinationType Is Nothing Then Throw New ArgumentNullException("destinationType")
                If destinationType.Equals(GetType(InstanceDescriptor)) Then
                    Dim typedItem = TryCast(value, TItem)
                    If typedItem Is Nothing Then Return MyBase.ConvertTo(context, culture, value, destinationType)
                    Return GetInstanceDescriptor(typedItem)
                End If
                Return MyBase.ConvertTo(context, culture, value, destinationType)
            End Function
            Protected Overridable Function GetInstanceDescriptor(item As TItem) As InstanceDescriptor
                If item.Value Is Nothing AndAlso Equals(item.Caption, String.Empty) AndAlso item.Tag Is Nothing Then
                    Dim ctor = GetType(TItem).GetConstructor(Type.EmptyTypes)
                    Return New InstanceDescriptor(ctor, New Object() {})
                End If
                If item.Tag IsNot Nothing Then
                    Dim ctor = GetType(TItem).GetConstructor(New Type() {GetType(Object), GetType(String), GetType(Object)})
                    Dim parameters = New Object() {item.Value, item.Caption, item.Tag}
                    Return New InstanceDescriptor(ctor, parameters)
                Else
                    Dim ctor = GetType(TItem).GetConstructor(New Type() {GetType(Object), GetType(String)})
                    Dim parameters = New Object() {item.Value, item.Caption}
                    Return New InstanceDescriptor(ctor, parameters)
                End If
            End Function
        End Class
    End Class
End Namespace
