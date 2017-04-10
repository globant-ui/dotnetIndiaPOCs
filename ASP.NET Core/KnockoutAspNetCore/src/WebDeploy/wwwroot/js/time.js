var vm = {
    TimeDT: ko.observable(),
    TimeString: ko.observable(),
    Name: ko.observable(),
    Sales: ko.observable(),
    Price: ko.observable()
};

function updateValues() {
    var data = new Date();
    vm.TimeDT(data);
    vm.TimeString(data);
     $.getJSON("/Redirect/GetPriceData", function (pricedata) {
         vm.Name(pricedata[0].name);
         vm.Sales(pricedata[0].sales);
         vm.Price(pricedata[0].price);
     });
    
}

updateValues();
setInterval(updateValues, 2000);

$(document).ready(function () {
 ko.applyBindings(vm);
});

 


