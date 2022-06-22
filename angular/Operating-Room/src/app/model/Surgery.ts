import { Time } from "@angular/common";

export interface Surgery {
    surgeryCode: number;
    idClass: number;
    priorityLevel: number;
    dangerLevel: number;
    idDoctor: number;
    surgeryDate: Date;
    duringSurg: Time;
    hasSches: boolean

}