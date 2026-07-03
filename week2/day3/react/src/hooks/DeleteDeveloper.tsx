        import axios from 'axios'
        import { useMutation, useQueryClient } from '@tanstack/react-query'

        const deleteDeveloper = async (id: string)  =>{
            const deleteRequest = await axios.delete(`https://6a47a86babfcbaade118cdc8.mockapi.io/api/developer/${id}`);
            return deleteRequest.data;
        }

        export const useDelete = () => {
            const queryClient = useQueryClient();
            return useMutation({
                mutationFn: deleteDeveloper,
                onSuccess: () =>{
                    queryClient.invalidateQueries({ queryKey: ['developers'], exact: false})
                }
            });
        }


