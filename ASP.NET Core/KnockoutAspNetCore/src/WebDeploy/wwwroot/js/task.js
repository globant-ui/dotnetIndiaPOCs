var initialData = [
    { name: "Well-Travelled Kitten", sales: 352, price: 75.95 },
    { name: "Speedy Coyote", sales: 89, price: 190.00 },
    { name: "Furious Lizard", sales: 152, price: 25.00 },
    { name: "Indifferent Monkey", sales: 1, price: 99.95 },
    { name: "Brooding Dragon", sales: 0, price: 6350 },
    { name: "Ingenious Tadpole", sales: 39450, price: 0.35 },
    { name: "Optimistic Snail", sales: 420, price: 1.50 }
];
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
    $.getJSON("/Redirect/GetAllData", function (data) {
        ko.applyBindings(new PagedGridModel(data));
    });
});




 


