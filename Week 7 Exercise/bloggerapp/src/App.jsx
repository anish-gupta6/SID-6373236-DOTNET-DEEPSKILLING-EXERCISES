import './App.css'
import Blog from './components/Blog'
import { blogs } from './utils/Blogs'
import { books } from './utils/Books'
import { courses } from './utils/Courses'

function App() {

  return (
    <Blog books={books} courses={courses} blogs={blogs} />
  )
}

export default App
