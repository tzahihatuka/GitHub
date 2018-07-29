class groundSteward extends flightAttendant {

    private _groundPosition: string = "first";
    

    public set groundPosition(Position: string) {
        this._groundPosition = Position;
    }

    public get groundPosition(): string {
        return this._groundPosition;
    }
    public print(): void {
        document.write("ground Steward details"  + "<br/>" + super.get_Info() + "groundPosition: " + this._groundPosition + "<br/>" + "<br/>"  );
    }
    public get_Info(): string {
        return this._groundPosition + super.get_Info();
    }
}