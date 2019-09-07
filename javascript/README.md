# JavaScript Notes

### Arrays
Push, pop, & iterate arrays
```
let a = [5, 6, 7];
a.push(8, 9, 10);
a.pop(); // remove last item
// iterate array
a.forEach((element) => {
    console.log(element)
});
```

Objects & Arrays are by reference & not cloned. Both a1 & a2 will get pushed the new value:
```
let a1 = ['foo', true, 5];
let a2 = a1;
a2.push(11);
console.log(a1);
console.log(a2);
```

Clone an array using [...foo]
```
let a1 = ['Jane', 5, true];
let a2 = [...a1];
a2.push(11);
console.log(a1);
console.log(a2);
```

### Objects
```
let obj = {
    firstName: 'Foo',
    lastName: 'Bar',
    address: {
        city: 'San Jose',
        state: 'CA'
    }
};
console.log(obj.firstName);
console.log(obj.address.city);
console.log(obj.address.country);  // does not yet exist
console.log( Object.keys(obj) );   // print keys at current level not children
console.log( Object.values(obj) ); // print values
console.log(obj.hasOwnProperty('firstName')); // check for specific key
```

Just like arrays, objects pass reference
To clone, assign an empty object to clone
```
let obj1 = {
    firstName: 'Foo'
};
let obj2 = Object.assign({}, obj1);
obj2.lastName = 'Bar';
console.log(obj1);
console.log(obj2);
```

### Element Selectors

By Element ID
```
<div id="example"></div>
document.getElementById('example').innerText = 'Hello world';
```

### ES6+

Template Literal
```
let word1 = 'Hello';
let word2 = 'world';
let output = `${word1}
${word2}
`;
console.log(output);
document.getElementById('example').innerText = output;
```

Destructing objects
```
const personalInformation = {
    firstName: 'Jane',
    lastName: 'Doe',
    city: 'Beverly Hills',
    state: 'CA',
    zipCode: 90210
};
console.log(`${personalInformation.firstName} ${personalInformation.lastName}`);
const {firstName, lastName} = personalInformation;
console.log(`${firstName} ${lastName}`);
```
