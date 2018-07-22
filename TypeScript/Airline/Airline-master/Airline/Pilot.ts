class pilot extends general_Iinfo {

    private _pilotLicenseNumber: number;
    private _seniorityYears: number;

    public set seniorityYears(seniority: number) {
        this._seniorityYears = seniority;
    }

    public get seniorityYears(): number {
        return this._seniorityYears;
    }
    public set pilotLicenseNumber(LicenseNumber: number) {
        this._pilotLicenseNumber = LicenseNumber;
    }

    public get pilotLicenseNumber(): number {
        return this._pilotLicenseNumber;
    }
    public print():void {
        document.write("pilot details" + "<br/>" + super.get_Info() + "<br/>" + "Seniority in Years: " + this._seniorityYears.toString() + "<br/>" + "Pilot License: " + this._pilotLicenseNumber.toString() + "<br/>" + "<br/>");
    }
    public get_Info(): string {
        return super.get_Info()+"<br/>"+"Seniority in Years :" + this._seniorityYears.toString();
    }
}