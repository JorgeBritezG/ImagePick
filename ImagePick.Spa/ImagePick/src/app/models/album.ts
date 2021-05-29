import { Image } from "./image";
import { User } from "./user";

export interface Album {
  id?: number;
  name: string;
  createdAt: Date;
  userId?: string;
  user?: User;
  images?: Image[];
}