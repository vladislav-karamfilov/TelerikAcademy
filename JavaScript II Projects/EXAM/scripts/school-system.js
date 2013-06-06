var schoolSystem = (function () {
    function Student(firstName, lastName, grade, mark) {
        this.firstName = firstName;
        this.latName = lastName;
        this.grade = grade;
        this.mark = mark;
    }

    function Course(title, startDate, totalStudents, students) {
        this.title = title;
        this.startDate = startDate;
        this.totalStudents = totalStudents;
        this.students = students;
    }

    function School(name, location, numberOfCourses, specialty, courses) {
        this.name = name;
        this.location = location;
        this.numberOfCourses = numberOfCourses;
        this.specialty = specialty;
        this.courses = courses;
    }

    return {
        Student: Student,
        Course: Course,
        School: School
    }
})();