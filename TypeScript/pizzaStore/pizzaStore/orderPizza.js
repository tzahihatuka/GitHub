var order = (function () {
    /**
         @constructor*/
    /**   @diameterNum {number} - enter the diameter of the pizza must be between 10-50*/
    /**     @slicesNum {number}  - enter the slices Number of the pizza must be between 1-8*/
    /**     @toppingsNum {number}  - enter the toppings Number of the pizza must be between 0-5*/
    function order(diameterNum, slicesNum, toppingsNum) {
        this._isBasicPizza = true;
        this.diameter = diameterNum;
        this.slices = slicesNum;
        this.toppings = toppingsNum;
        order._sumOfToppings += this._toppings;
    }
    Object.defineProperty(order.prototype, "diameter", {
        get: function () {
            return this._diameter;
        },
        /**   @diameterNum {number} - enter or get the diameter of the pizza must be between 10-50*/
        set: function (diametersiz) {
            this._diameter = diametersiz >= 10 && diametersiz <= 50 ? diametersiz : this.random(50, 10);
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(order.prototype, "slices", {
        get: function () {
            return this._slices;
        },
        /**     @slicesNum {number}  - enter or get the slices Number of the pizza must be between 1-8*/
        set: function (slicesNum) {
            this._slices = slicesNum >= 1 && slicesNum <= 8 ? slicesNum : this.random(8, 1);
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(order.prototype, "toppings", {
        get: function () {
            return this._toppings;
        },
        /**     @toppingsNum {number}  - enter or get the toppings Number of the pizza must be between 0-5*/
        set: function (toppingsNum) {
            this._toppings = toppingsNum >= 0 && toppingsNum <= 5 ? toppingsNum : this.random(5, 0);
            this._isBasicPizza = this._toppings > 0 ? false : true;
        },
        enumerable: true,
        configurable: true
    });
    order.prototype.random = function (x, y) {
        var tamp;
        if (x < y) {
            tamp = x;
            x = y;
            y = tamp;
        }
        var rand = Math.round((Math.random() * (x - y)) + y);
        return rand;
    };
    /**     @get_sumOfToppings {number}  - get the sum Of all Toppings Number of all pizzas*/
    order.get_sumOfToppings = function () { return order._sumOfToppings; };
    /**   @getisBasicPizza {number} - get true or false if there is Toppings*/
    order.prototype.getisBasicPizza = function () {
        var BasicPizza = this._isBasicPizza ? "false" : "true";
        return BasicPizza;
    };
    order.prototype.print = function () {
        return ("diameter : " + this._diameter + "<br/>slices : " + this._slices + "<br/>toppings : " + this._toppings + "<br/> ");
    };
    return order;
}());
order._sumOfToppings = 0;
//# sourceMappingURL=orderPizza.js.map