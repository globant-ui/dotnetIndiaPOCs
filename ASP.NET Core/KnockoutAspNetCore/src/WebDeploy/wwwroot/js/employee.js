function Employee() {
    var self = this;
    self.FirstName = ko.observable("");
    self.LastName = ko.observable("");
    self.FullName = ko.computed(function () {
        return self.FirstName() + " " + self.LastName();
    });
   // self.DateOfBirth = ko.observable("");
    //self.EducationList = ko.observableArray();
    //self.Gender = ko.observable("0");
   // self.DepartmentList = ko.observableArray([{ Id: '0', Name: "CSE" }, { Id: '1', Name: "MBA" }]);
    //self.DepartmentId = ko.observable("1");
}
function EmployeeVM() {
    var self = this;
    self.Employee = new Employee();
    self.reset = function () {
        self.Employee.FirstName("");
        self.Employee.LastName("");
        //self.Employee.DateOfBirth("");
    };
    self.submit = function () {
        debugger;
        var emp = ko.toJSON(self.Employee);
        $.ajax({
            type: 'POST',
            url: '/Home/SaveEmployee',
            data: emp,
            datatype: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                window.location.href = '/Home/About';
            },
            error: function () {
                alert('error happened' + Error);
            }
        });
   };
    
};

$(document).ready(function ()
{
    var _vm = new EmployeeVM();
    ko.applyBindings(_vm);
});

