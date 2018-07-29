
let pizza1: order = new order(15,8,0);
let pizza2: order = new order(45, 2, 4);
let pizza3: order = new order(10,5,3);
let pizza4: order = new order();
let pizza5: order = new order();
let arr: Array<order> = new Array<order>(pizza1, pizza2, pizza3, pizza4, pizza5);
for (let i in arr) {
    document.write(arr[i].print());
    document.write(arr[i].getisBasicPizza() +"<br/><br/>");
}

document.write(`<br/> sum Of all Toppings: ${order.get_sumOfToppings()}<br/>`);




