export interface User {
  id: number;
  firstName?: string;
  lastName: string;
  email: string;
  iam: string;
  kerberos: string;
  name: string;
  isAdmin: boolean;
}

export type RoleName = "Admin" | "Sponsor";

export interface Account {
  id: number;
  name: string;
  status: string;
  canSponsor: boolean;
  createdOn: string;
  cluster: string;
  owner?: User;
  sponsor?: Account;
  updatedOn: string;
}

export interface RequestPostModel {
  sponsorId: number;
  sshKey: string;
}

export interface CreateSponsorPostModel {
  lookup: string;
  name: string;
}

export interface AppContextShape {
  antiForgeryToken: string;
  user: {
    detail: User;
  };
  accounts: Account[];
}

export interface PromiseStatus {
  pending: boolean;
  success: boolean;
}
