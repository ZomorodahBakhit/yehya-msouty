
import './pagesStyle.scss';
import {Name} from '../context/Name';
import { useContext } from 'react';

export default function UpperNav() {  
  const context = useContext(Name);
  return (
    <div className="Upper-Nav">
        welcome {context.name} this is best developers website in the world 
    </div>
  )
  }