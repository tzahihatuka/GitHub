var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var passenger = (function (_super) {
    __extends(passenger, _super);
    function passenger() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this._passengerPassport = 65484311;
        return _this;
    }
    Object.defineProperty(passenger.prototype, "passengerPassport", {
        get: function () {
            return this._passengerPassport;
        },
        set: function (Passport) {
            this._passengerPassport = Passport;
        },
        enumerable: true,
        configurable: true
    });
    passenger.prototype.print = function () {
        document.write("passenger details" + "<br/>" + _super.prototype.get_Info.call(this) + "<br/>" + "Passenger Passport: " + this._passengerPassport.toString() + "<br/>" + "<br/>");
    };
    return passenger;
}(general_Iinfo));
//# sourceMappingURL=passenger.js.map