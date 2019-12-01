export interface Address {
    street1: string;
    street2: string;
    city: string;
    state: string;
    zip: string;
}
export interface Name {
    first: string;
    middle: string;
    last: string;
}
export interface User {
    name: Name;
    address: Address;
    email: string;
    phone: string;
    isAdmin: boolean;
}
