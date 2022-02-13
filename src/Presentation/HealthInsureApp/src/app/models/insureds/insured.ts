export interface Insured {
  id: number;
  insuredFirstName: string;
  insuredLastName: string;
  identityNumber: string;
  birthYear: number;
  gender: string;
  degree: string;
  weight: number;
  height: number;
  bodyMassIndex: number;
  status: boolean;
  customerId: number;
  policyId: number;
}
