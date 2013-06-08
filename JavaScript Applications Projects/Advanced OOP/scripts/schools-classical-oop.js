var Person = Class.create({
    init: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    },
    introduce: function () {
        var introducement = "First name: " + this.firstName + "<br />";
        introducement += "Last name: " + this.lastName + "<br />";
        introducement += "Age: " + this.age + "<br />";
        return introducement;
    }
});

var Student = Class.create({
    init: function (firstName, lastName, age, grade) {
        this._super.init(firstName, lastName, age);
        this.firstName = this._super.firstName;
        this.lastName = this._super.lastName;
        this.age = this._super.age;
        this.grade = grade;
    },
    introduce: function () {
        return this._super.introduce() + "Grade: " + this.grade + "<br />";
    }
});

Student.inherit(Person);

var Teacher = Class.create({
    init: function (firstName, lastName, age, speciality) {
        this._super.init(firstName, lastName, age);
        this.firstName = this._super.firstName;
        this.lastName = this._super.lastName;
        this.age = this._super.age;
        this.speciality = speciality;
    },
    introduce: function () {
        return this._super.introduce() + "Speciality: " + this.speciality + "<br />";
    }
});

Teacher.inherit(Person);

var School = Class.create({
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    },
    addClass: function (newClass) {
        this.classes.push(newClass);
    },
    toString: function () {
        var output, i, classesCount;
        output = "Name: " + this.name + "<br />";
        output += "Town: " + this.town + "<br />";
        classesCount = this.classes.length;
        if (classesCount > 0) {
            output += "Classes:<br />";
            for (i = 0; i < classesCount; i++) {
                output += this.classes[i].toString() + "<br />";
            }
        }

        return output;
    }
});

var SchoolClass = Class.create({
    init: function (name, capacity, students, formTeacher) {
        this.name = name;
        this.capacity = capacity;
        this.students = students;
        this.formTeacher = formTeacher;
    },
    addStudent: function (newStudent) {
        if (this.students.length + 1 > this.capacity) {
            throw new Error(
                "The capacity of the class is reached and cannot add new students to it!");
        }

        this.students.push(newStudent);
    },
    toString: function () {
        var output, i, studentsCount;
        output = "-> Class name: " + this.name + "<br />";
        output += "-> Capacity: " + this.capacity + "<br />";
        studentsCount = this.students.length;
        if (studentsCount > 0) {
            output += "-> Students:<br />";
            for (i = 0; i < studentsCount; i++) {
                output += this.students[i].introduce() + "<br />";
            }
        }

        output += "-> Form-teacher:<br />" + this.formTeacher.introduce();
        return output;
    }
});
