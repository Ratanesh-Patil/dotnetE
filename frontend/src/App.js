import { BrowserRouter,Routes,Route } from 'react-router-dom';
import './App.css';
import AddStudent from './componets/AddStudent';
import StudentList from './componets/StudentList';

function App() {
  return (
  <BrowserRouter>
  <Routes>
    <Route path="/" element={<StudentList></StudentList>}></Route>
    <Route path='/Addstudent' element={<AddStudent></AddStudent>}></Route>
  </Routes>
  </BrowserRouter>
  );
}

export default App;
