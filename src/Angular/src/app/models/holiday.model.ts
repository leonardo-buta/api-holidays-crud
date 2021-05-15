import { HolidayVariableDate } from "./holiday-variable-date.model";

export class Holiday {
    id?: number;
    date?: string;
    title?: string;
    description?: string;
    legislation?: string;
    type?: string;
    startTime?: string;
    endTime?: string;
    variableDates? : HolidayVariableDate[];
}
