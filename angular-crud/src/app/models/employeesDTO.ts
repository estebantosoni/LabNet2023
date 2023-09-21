
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

}