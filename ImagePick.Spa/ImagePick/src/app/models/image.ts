import { Album } from "./album";

export interface Image {
  id: string;
  regularUrl: string;
  smallUrl: string;
  thumbUrl: string;
  userName: string;
  userProfileImageSmall: string;
  userHtmlLink: string;
  albumId?: number;
  album?: Album;
}