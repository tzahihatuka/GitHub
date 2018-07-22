class flightAttendant extends pilot {

    private _department:string="First Class";
    private _originCountry: string="Israel";

    
    public set department(departmentClass: string) {
        this._department = departmentClass;
    }

    public get department(): string {
        return this._department;
    }
    public set originCountry(countryOrigin: string) {
        this._originCountry = countryOrigin;
    }

    public get originCountry(): string {
        return this._originCountry;
    }
    public print(): void {
        document.write("flight Attendant details" + "<br/>" + super.get_Info() + "<br/>" + "Origin Country: " + this._originCountry + "<br/>" + "Department: " + this._department + "<br/>" + "<br/>" );
    }
    public get_Info(): string {
        return super.get_Info() + "<br/>" + "Origin Country: " + this._originCountry + "<br/>"   ;
    }
}