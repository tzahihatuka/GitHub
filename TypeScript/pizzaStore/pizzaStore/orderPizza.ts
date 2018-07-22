class order {

    private _diameter: number;

    private _slices: number;
    private _toppings: number;

    private static _sumOfToppings: number = 0;
    private _isBasicPizza: boolean = true;
/**
     @constructor*/

  /**   @diameterNum {number} - enter the diameter of the pizza must be between 10-50*/

 /**     @slicesNum {number}  - enter the slices Number of the pizza must be between 1-8*/

 /**     @toppingsNum {number}  - enter the toppings Number of the pizza must be between 0-5*/
         
    public constructor(diameterNum?: number, slicesNum?: number, toppingsNum?: number) {
        this.diameter = diameterNum;
        this.slices = slicesNum;
        this.toppings = toppingsNum;
        order._sumOfToppings += this._toppings;
    }
     /**   @diameterNum {number} - enter or get the diameter of the pizza must be between 10-50*/
    public set diameter(diametersiz: number) {

        this._diameter = diametersiz >= 10 && diametersiz <= 50 ? diametersiz : this.random(50, 10);
    }

    public get diameter(): number {
        return this._diameter;
    }
    /**     @slicesNum {number}  - enter or get the slices Number of the pizza must be between 1-8*/
   
    public set slices(slicesNum: number) {
        this._slices = slicesNum >= 1 && slicesNum <= 8 ? slicesNum : this.random(8, 1);
    }
     
    public get slices(): number {
        return this._slices;
    }

      /**     @toppingsNum {number}  - enter or get the toppings Number of the pizza must be between 0-5*/
    public set toppings(toppingsNum: number) {
        this._toppings = toppingsNum >= 0 && toppingsNum <= 5 ? toppingsNum : this.random(5, 0);
        this._isBasicPizza = this._toppings > 0 ? false : true;
    }
   
    public get toppings(): number {
        return this._toppings;
    }
    private random(x: number, y: number): number {
        let tamp: number;
        if (x < y) { tamp = x; x = y; y = tamp; }
        let rand: number = Math.round((Math.random() * (x - y)) + y);
        return rand;
    }
    /**     @get_sumOfToppings {number}  - get the sum Of all Toppings Number of all pizzas*/
    public static get_sumOfToppings(): number { return order._sumOfToppings }
    /**   @getisBasicPizza {number} - get true or false if there is Toppings*/
    public getisBasicPizza(): string {
        let BasicPizza: string = this._isBasicPizza ? "false" : "true"
        return BasicPizza;
    }
    public print(): string {
        return (`diameter : ${this._diameter}<br/>slices : ${this._slices}<br/>toppings : ${this._toppings}<br/> `)
    }
}