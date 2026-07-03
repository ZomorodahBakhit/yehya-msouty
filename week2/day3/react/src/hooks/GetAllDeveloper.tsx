import axios from "axios";
import {useQuery, type UseQueryResult} from "@tanstack/react-query";
import type { Developer } from "../types/DeveloperType";
const fetchData = async ():Promise<Developer[]> => {  
  const response = await axios.get("https://6a47a86babfcbaade118cdc8.mockapi.io/api/developer");
  return response.data;
}

export const useGetAll = ():UseQueryResult<Developer[]> => {
  const query = useQuery(
    { queryKey: ["getAll"], 
      queryFn: fetchData,
      staleTime: 1000 * 10
    })
    return query;
}