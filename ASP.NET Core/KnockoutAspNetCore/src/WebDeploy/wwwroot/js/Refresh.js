var initialData = [
    { name: "Well-Travelled Kitten", sales: 352, price: 75.95 },
    { name: "Speedy Coyote", sales: 89, price: 190.00 },
    { name: "Furious Lizard", sales: 152, price: 25.00 },
    { name: "Indifferent Monkey", sales: 1, price: 99.95 },
    { name: "Brooding Dragon", sales: 0, price: 6350 },
    { name: "Ingenious Tadpole", sales: 39450, price: 0.35 },
    { name: "Optimistic Snail", sales: 420, price: 1.50 }
];
function Product() {
    this.ProductName = ko.observable("");
    this.SalesCount = ko.observable("");
    this.Price = ko.observable("");
}
var PagedGridModel = function (items) {
    this.items = ko.observableArray(items);
    this.Product = new Product();
    this.addItem = function () {
        this.items.push({ name: this.Product.ProductName, sales: this.Product.SalesCount, price: this.Product.Price });
        alert("Product Added Successfully");
        
    };

    this.sortByName = function () {
        this.items.sort(function (a, b) {
            return a.name < b.name ? -1 : 1;
        });
    };

    this.jumpToFirstPage = function () {
        this.gridViewModel.currentPageIndex(0);
    };

    this.gridViewModel = new ko.simpleGrid.viewModel({
        data: this.items,
        columns: [
            { headerText: "Item Name", rowText: "name" },
            { headerText: "Sales Count", rowText: "sales" },
            { headerText: "Price", rowText: "price" },
            { headerText: "Delete", rowText: "Delete" }
        ],
        pageSize: 4
    });
};
$(document).ready(function () {
    ko.applyBindings(new PagedGridModel(initialData));
});

