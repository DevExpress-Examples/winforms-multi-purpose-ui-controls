namespace DevExpress.UITemplates.Collection.Repositories {
    using System.Collections.Generic;
    using System.Linq;
    using DevExpress.UITemplates.Collection.Models;

    public class InMemorySampleRepositoryForEmployees : InMemoryRepository<long, Employee> {
        protected override void OnInitializeStorage(Dictionary<long, Employee> dataBase) {
            dataBase.Add(0x01L, Assign(CreateEntity(), EmployeeSampleData.Employee1));
            dataBase.Add(0x02L, Assign(CreateEntity(), EmployeeSampleData.Employee2));
            dataBase.Add(0x03L, Assign(CreateEntity(), EmployeeSampleData.Employee3));
            dataBase.Add(0x04L, Assign(CreateEntity(), EmployeeSampleData.Employee4));
            dataBase.Add(0x05L, Assign(CreateEntity(), EmployeeSampleData.Employee5));
        }
        public override long NewEntityID {
            get { return long.MinValue; }
        }
        protected override long GenerateNextID() {
            return StorageKeys.Max() + 1;
        }
        protected override Employee CreateEntity() {
            return new Employee() { Address = new USAddress() };
        }
        protected override Employee Assign(Employee target, Employee source) {
            target.Assign(source);
            return target;
        }
        protected override bool Equals(Employee target, Employee source) {
            return target.Equals(source);
        }
    }
    public class InMemorySampleRepositoryForSubordinate : InMemoryRepository<long, Subordinate> {
        protected override void OnInitializeStorage(Dictionary<long, Subordinate> dataBase) {
            var ceo = CreateEntity();
            ceo.Assign(EmployeeSampleData.Employee3);
            var e1 = CreateEntity();
            e1.Assign(EmployeeSampleData.Employee1);
            var e2 = CreateEntity();
            e2.Assign(EmployeeSampleData.Employee2);
            var e4 = CreateEntity();
            e4.Assign(EmployeeSampleData.Employee4);
            var e5 = CreateEntity();
            e5.Assign(EmployeeSampleData.Employee5);
            ceo.SupervisorID = -1;
            e1.SupervisorID = ceo.ID;
            e2.SupervisorID = ceo.ID;
            e4.SupervisorID = ceo.ID;
            e5.SupervisorID = ceo.ID;
            dataBase.Add(ceo.ID, ceo);
            dataBase.Add(e1.ID, e1);
            dataBase.Add(e2.ID, e2);
            dataBase.Add(e4.ID, e4);
            dataBase.Add(e5.ID, e5);
        }
        public override long NewEntityID {
            get { return long.MinValue; }
        }
        protected override long GenerateNextID() {
            return StorageKeys.Max() + 1;
        }
        protected override Subordinate CreateEntity() {
            return new Subordinate() { Address = new USAddress() };
        }
        protected override Subordinate Assign(Subordinate target, Subordinate source) {
            target.Assign(source);
            return target;
        }
        protected override bool Equals(Subordinate target, Subordinate source) {
            return target.Equals(source);
        }
    }
}