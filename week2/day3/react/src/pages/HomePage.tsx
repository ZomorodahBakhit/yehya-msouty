import { Link } from "react-router-dom";
import "./pagesStyle.scss";
export default function HomePage() {
  return (
    <div className="Home-Page">
      <div style = {{display:"flex", flexDirection:"row", alignItems:"center"}}>
      <span style={{ fontSize: "30px" }}>Developers section :</span>
      <Link to="/developers">
        <button
          style={{
            borderRadius: "10px",
            fontSize: "30px",
            border: "none",
            padding: "10px",
            cursor: "pointer",
            margin: "20px",
          }}
          >
          View Developers
        </button>
      </Link>
          </div>
    </div>
  );
}
