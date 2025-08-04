import React from 'react'

const Blog = (props) => {
    const bookdet =(
        <ul>
            {props.books.map((book) => (
                <div key={book.id}>
                    <h3>{book.bname}</h3>
                    <h4>{book.price}</h4>
                </div>
            ))}
        </ul>
    )

    const coursedet =(
        <ul>
            {props.courses.map((course) => (
                <div key={course.id}>
                    <h3>{course.cname}</h3>
                    <h4>{course.date}</h4>
                </div>
            ))}
        </ul>
    )

    const content =(
        <ul>
            {props.blogs.map((blog) => (
                <div key={blog.id}>
                    <h1>{blog.blogname}</h1>
                    <h3>{blog.author}</h3>
                    <p>{blog.content}</p>
                </div>
            ))}
        </ul>
    )
  return (
    <div className='container'>
        <div className="mystyle1">
        <h1>Course Details</h1>
        {coursedet}
      </div>
      <div className="border"/>
      <div className="st2">
        <h1>Book Details</h1>
        {bookdet}
      </div>
      <div className="border"/>
      <div className="v1">
        <h1>Blog Details</h1>
        {content}
      </div>
    </div>
  )
}

export default Blog
