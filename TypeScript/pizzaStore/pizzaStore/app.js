var pizza1 = new order(15, 8, 0);
var pizza2 = new order(45, 2, 4);
var pizza3 = new order(10, 5, 3);
var pizza4 = new order();
var pizza5 = new order();
var arr = new Array(pizza1, pizza2, pizza3, pizza4, pizza5);
for (var i in arr) {
    document.write(arr[i].print());
    document.write(arr[i].getisBasicPizza() + "<br/><br/>");
}
document.write("<br/> sum Of all Toppings: " + order.get_sumOfToppings() + "<br/>");
//# sourceMappingURL=app.js.map