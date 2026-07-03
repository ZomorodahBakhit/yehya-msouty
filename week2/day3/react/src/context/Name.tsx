import { createContext } from "react";

export const Name  = createContext({
  name : "name",
  setName : (name: string) => {},
  setOpen : (open: boolean) => {}
});