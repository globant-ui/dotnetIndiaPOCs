var DynamicObservable = function (data, rowIndex, parentSelectedRowIndex, parentSelectedColumnName) {
    self = this
    for (var key in data) {
        self[key] = ko.observable(data[key]);
    }

    self.selectCell = function (columnName) {
        parentSelectedRowIndex(rowIndex)
        parentSelectedColumnName(columnName)
    }

    self.templateToUse = function (columnName) {
        return rowIndex == parentSelectedRowIndex() && columnName == parentSelectedColumnName()
                        ? 'write' : 'read';
    };
};

var ViewModel = function (data) {
    var self = this;

    self.parentSelectedRowIndex = ko.observable(null);
    self.parentSelectedColumnName = ko.observable(null);

    self.items = ko.observableArray(ko.utils.arrayMap(data, function (i) {
        var myIndex = data.indexOf(i);
        return new DynamicObservable(i, myIndex, self.parentSelectedRowIndex, self.parentSelectedColumnName);
    }));
    self.columns = ko.observableArray();
    for (var key in data[0]) {
        self.columns.push(key);
    }

    self.cellClick = function () {
        

    };
}

$(document).ready(function () {
    $.getJSON("/Redirect/GetAllData", function (data) {
        ko.applyBindings(new ViewModel(data));
    });
});




 


