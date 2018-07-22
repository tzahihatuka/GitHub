var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var pilot = (function (_super) {
    __extends(pilot, _super);
    function pilot() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Object.defineProperty(pilot.prototype, "seniorityYears", {
        get: function () {
            return this._seniorityYears;
        },
        set: function (seniority) {
            this._seniorityYears = seniority;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(pilot.prototype, "pilotLicenseNumber", {
        get: function () {
            return this._pilotLicenseNumber;
        },
        set: function (LicenseNumber) {
            this._pilotLicenseNumber = LicenseNumber;
        },
        enumerable: true,
        configurable: true
    });
    pilot.prototype.print = function () {
        document.write("pilot details" + "<br/>" + _super.prototype.get_Info.call(this) + "<br/>" + "Seniority in Years: " + this._seniorityYears.toString() + "<br/>" + "Pilot License: " + this._pilotLicenseNumber.toString() + "<br/>" + "<br/>");
    };
    pilot.prototype.get_Info = function () {
        return _super.prototype.get_Info.call(this) + "<br/>" + "Seniority in Years :" + this._seniorityYears.toString();
    };
    return pilot;
}(general_Iinfo));
//# sourceMappingURL=pilot.js.map