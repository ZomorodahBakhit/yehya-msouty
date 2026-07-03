import axios from "axios";
import { useMutation } from "@tanstack/react-query";
import type { Developer } from "../types/DeveloperType";

const addDeveloper = async (developer: Developer) => {
  const response = await axios.post("https://6a47a86babfcbaade118cdc8.mockapi.io/api/developer",
    developer
  );

  return response.data;
};

export const usePost = () => {
  return useMutation({
    mutationFn: addDeveloper,
  });
};