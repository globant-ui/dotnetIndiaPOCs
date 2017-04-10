var jsonData = null;
function Product() {
    var self = this;
    self.name = "";
    self.sales = "";
    self.price = "";
}
var PagedGridModel = function (items) {
    var self = this;
    self.items = ko.observableArray(items);
    self.productList = ko.observableArray([]);
    self.Product = new Product();

        self.addItem = function () {
        self.items.push({ name: self.Product.name, sales: self.Product.sales, price: self.Product.price });
        alert("Product Added Successfully");
    };
   
    self.sortByName = function () {
        self.items.sort(function (a, b) {
            return a.name < b.name ? -1 : 1;
        });
    };

    self.jumpToFirstPage = function () {
        self.gridViewModel.currentPageIndex(0);
    };

    self.gridViewModel = new ko.simpleGrid.viewModel({
        data: self.items,
        columns: [
            { headerText: "Item Name", rowText: "name" },
            { headerText: "Sales Count", rowText: "sales" },
            { headerText: "Price", rowText: "price" }
           ],
        pageSize: 4
    });
};
$(document).ready(function () {
    $.getJSON("/Home/GetAllData", function (data) {
        ko.applyBindings(new PagedGridModel(data));
    });
});




 


