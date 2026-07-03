import "./componetnsStyle.scss";
import { useContext } from "react";
import { Name } from "../context/Name";
import { createPortal } from "react-dom";
export default function Dialog({
  description,
  btnText,
}: {
  description: string;
  btnText: string;
}) {
  const { name, setName, setOpen } = useContext(Name);
  return createPortal(
    <div className="overlay">
      <div className="Dialog">
        <p>{description}</p>
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        <button onClick={() => {
          setName(name);
          setOpen(false)
          }}>{btnText}</button>
      </div>
    </div>,
    document.getElementById("root-modal") as HTMLElement,
  );
}
