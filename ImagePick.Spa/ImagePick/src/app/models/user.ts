import { Album } from "./album";

export interface User {
  id: string;
  name: string;
  firstName: string;
  lastName: string;
  Albums?: Album[];
}