var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var groundSteward = (function (_super) {
    __extends(groundSteward, _super);
    function groundSteward() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this._groundPosition = "first";
        return _this;
    }
    Object.defineProperty(groundSteward.prototype, "groundPosition", {
        get: function () {
            return this._groundPosition;
        },
        set: function (Position) {
            this._groundPosition = Position;
        },
        enumerable: true,
        configurable: true
    });
    groundSteward.prototype.print = function () {
        document.write("ground Steward details" + "<br/>" + _super.prototype.get_Info.call(this) + "groundPosition: " + this._groundPosition + "<br/>" + "<br/>");
    };
    groundSteward.prototype.get_Info = function () {
        return this._groundPosition + _super.prototype.get_Info.call(this);
    };
    return groundSteward;
}(flightAttendant));
//# sourceMappingURL=ground steward.js.map