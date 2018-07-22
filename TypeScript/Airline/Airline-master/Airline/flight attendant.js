var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var flightAttendant = (function (_super) {
    __extends(flightAttendant, _super);
    function flightAttendant() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this._department = "First Class";
        _this._originCountry = "Israel";
        return _this;
    }
    Object.defineProperty(flightAttendant.prototype, "department", {
        get: function () {
            return this._department;
        },
        set: function (departmentClass) {
            this._department = departmentClass;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(flightAttendant.prototype, "originCountry", {
        get: function () {
            return this._originCountry;
        },
        set: function (countryOrigin) {
            this._originCountry = countryOrigin;
        },
        enumerable: true,
        configurable: true
    });
    flightAttendant.prototype.print = function () {
        document.write("flight Attendant details" + "<br/>" + _super.prototype.get_Info.call(this) + "<br/>" + "Origin Country: " + this._originCountry + "<br/>" + "Department: " + this._department + "<br/>" + "<br/>");
    };
    flightAttendant.prototype.get_Info = function () {
        return _super.prototype.get_Info.call(this) + "<br/>" + "Origin Country: " + this._originCountry + "<br/>";
    };
    return flightAttendant;
}(pilot));
//# sourceMappingURL=flight attendant.js.map