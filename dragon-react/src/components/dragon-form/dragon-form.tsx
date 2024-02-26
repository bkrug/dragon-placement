import { useState, ChangeEvent, FormEvent} from "react";
import dragon from '../../models/dragon';

interface DragonFormProps {
    sourceData: dragon;
}

export default function DragonForm({ sourceData }: DragonFormProps) {
    const [formData, setFormData] = useState(sourceData);

    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.target;
        setFormData((prevFormData) => ({ ...prevFormData, [name]: value }));
    };

    const handleBooleanChange = (event: ChangeEvent<HTMLInputElement>) => {
        const { name, checked } = event.target;
        setFormData((prevFormData) => ({ ...prevFormData, [name]: checked }));
    };

    const handleSubmit = (event: FormEvent<HTMLFormElement> ) => {
        event.preventDefault();
        console.log(formData);
    };

    return (
        <form onSubmit={handleSubmit}>
        <label htmlFor="name">Name:</label>
        <input type="text" id="name" name="name" value={formData.name} onChange={handleChange}/>

        <label htmlFor="title">Title:</label>
        <input type="text" id="title" name="title" value={formData.title} onChange={handleChange}/>

        <label htmlFor="hasFire">Breathes Fire:</label>
        <input type="checkbox" id="hasFire" name="hasFire" checked={formData.hasFire} onChange={handleBooleanChange}/>

        <label htmlFor="hasFlight">Can Fly:</label>
        <input type="checkbox" id="hasFlight" name="hasFlight" checked={formData.hasFlight} onChange={handleBooleanChange}/>        

        <button type="submit">Submit</button>
        </form>
    );
}