export enum EmploymentStatus{
    Active = 1,
    OnLeave = 2,
    Terminated = 3
}


export function getEmploymentStatus(intvalue: number) : string{
    switch(intvalue){
        case EmploymentStatus.Active:
            return "Active";
            case EmploymentStatus.OnLeave:
            return "OnLeave";
            case EmploymentStatus.Terminated:
            return "Terminated";
            default :
            return "Unknown";
    }
}