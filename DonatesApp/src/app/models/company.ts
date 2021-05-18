import { Currency } from './currency';

export class Company {
    id!: number;
    name!: string;
    amount!: number;
    currency!: Currency;
    policyType! : number;
    details! : string;
    conditions! : string;
    currencyType! :number;
    conversionRate! : number;

    userID!: number;
}