
export class EmployeesDTO {
    private ID: number = 0;
    private FirstName: string = "";
    private LastName: string = "";
    private Title: string = "";
    private HireDate: Date = new Date();
    private City: string = "";
    private Country: string = "";
    private HomePhone: string = "";

    public getID(): number{
        return this.ID;
    }

    public getFirstName(): string{
        return this.FirstName;
    }

    public getLastName(): string{
        return this.LastName;
    }

    public getTitle(): string{
        return this.Title;
    }

    public getHireDate(): Date{
        return this.HireDate;
    }

    public setHireDate(date: Date){
        this.HireDate = date;
    }

    public getCity(): string{
        return this.City;
    }

    public getCountry(): string{
        return this.Country;
    }

    public getHomePhone(): string{
        return this.HomePhone;
    }

}