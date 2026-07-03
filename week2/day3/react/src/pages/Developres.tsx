import "./pagesStyle.scss";
import { useGetAll } from "../hooks/GetAllDeveloper";
import { useContext } from "react";
import { Name } from "../context/Name";
import { useDelete } from "../hooks/DeleteDeveloper";
import { usePost } from "../hooks/AddDeveloper";
import { useUpdate } from "../hooks/UpdateDeveloper";
function App() {
  const name = useContext(Name).name;

  const { data } = useGetAll();

  const DeleteDeveloperMutation = useDelete();
  const AddDeveloperMutation = usePost();
  const UpdateDeveloperMutation = useUpdate();

  const handleDelete = (id: string) => {
    DeleteDeveloperMutation.mutate(id);
  };

  const handleUpdate = (id: string) => {
    UpdateDeveloperMutation.mutate({ id, name });
  };
  const handleAdd = () => {
    AddDeveloperMutation.mutate({name});
  };

  return (
    <div className="developers-container">
      <h2>Developers</h2>

      <div className="developers-grid">
        {data?.map((developer) => (
          <div className="developer-card" key={developer.id}>
            <h3>{developer.name}</h3>

            <div className="actions">
              <button
                className="btn update"
                onClick={() => handleUpdate(developer.id)}
              >
                Set My Name Instead
              </button>

              <button
                className="btn delete"
                onClick={() => handleDelete(developer.id)}
              >
                Delete
              </button>
            </div>
          </div>
        ))}
      </div>

      <button className="btn" onClick={() => handleAdd()}>
        Add Your Self
      </button>
    </div>
  );
}

export default App;
