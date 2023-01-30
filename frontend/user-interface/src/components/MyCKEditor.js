import { CKEditor } from "@ckeditor/ckeditor5-react";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";

function MyCKEditor(props) {
  return (
    <CKEditor 
        editor={ClassicEditor}
        data={props.value}
        onChange={props.onChange}
    />
  );
}

export default MyCKEditor;
