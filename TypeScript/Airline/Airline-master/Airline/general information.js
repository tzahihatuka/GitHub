var general_Iinfo = (function () {
    function general_Iinfo() {
        this._firstName = "Jon";
        this._lastName = "Do";
    }
    Object.defineProperty(general_Iinfo.prototype, "firstName", {
        get: function () {
            return this._firstName;
        },
        set: function (FName) {
            this._firstName = FName;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(general_Iinfo.prototype, "lastName", {
        get: function () {
            return this._firstName;
        },
        set: function (LName) {
            this._lastName = LName;
        },
        enumerable: true,
        configurable: true
    });
    general_Iinfo.prototype.get_Info = function () {
        return "First Name: " + this._firstName + "<br/>" + "Last Name: " + this._lastName;
    };
    return general_Iinfo;
}());
//# sourceMappingURL=general information.js.map