export interface Product {
  lender: string;
  interestRate: number;
  interestType: InterestType;
  interestTypeName?: string;
  loanToValue: number;
}

export enum InterestType {
  Variable = 1,
  Fixed = 2,
}

export enum Routes {
  Search = "Search",
  Register = "RegisterUser",
}

/**
 * Types used within the Vuex store.
 */
export interface State {
  token: string;
  isAuthenticated: boolean;
}

export enum Mutations {
  Authenticate = "AUTHENTICATE",
  Logout = "LOGOUT",
}

export enum Actions {
  Authenticate = "authenticate",
  Logout = "logout",
}
/**
 * ================================
 */
