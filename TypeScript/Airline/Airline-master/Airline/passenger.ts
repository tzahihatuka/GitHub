class passenger extends general_Iinfo {

    private _passengerPassport: number=65484311;

    public set passengerPassport(Passport: number) {
        this._passengerPassport = Passport
    }
    public get passengerPassport():number {
        return this._passengerPassport;
    }

    public print(): void {
        document.write("passenger details"  + "<br/>" +super.get_Info() + "<br/>" +"Passenger Passport: " + this._passengerPassport.toString() +   "<br/>" + "<br/>");
    }
}
   
