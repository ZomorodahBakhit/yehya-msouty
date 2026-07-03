import axios from "axios";
import { useMutation } from "@tanstack/react-query";
import type { Developer } from "../types/DeveloperType";

const updateDeveloper = async (developer: Developer) => {
  const response = await axios.put(
  `https://6a47a86babfcbaade118cdc8.mockapi.io/api/developer/${developer.id}`,
    developer
  );

  console.log (response.data);
  return response.data;
};

export const useUpdate = () => {
  return useMutation({
    mutationFn: updateDeveloper,
  });
};