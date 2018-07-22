class general_Iinfo {
    private _firstName: string ="Jon";
    private _lastName: string="Do";


    public set firstName(FName: string) {

        this._firstName = FName;
    }
    public get firstName(): string {
        return this._firstName;
    }
    public set lastName(LName: string) {

        this._lastName = LName;
    }
    public get lastName(): string {
        return this._firstName;
    }

    public get_Info(): string {
        return "First Name: " + this._firstName + "<br/>" +"Last Name: "+ this._lastName;
    }
}


