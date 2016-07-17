import {bootstrap} from "angular2/platform/browser";
import {Component} from "angular2/core";

@Component({
    selector: "content-page",
    template: "<h3>Contact Lester</h3>"
})

export class ContactPage{

}

bootstrap(ContactPage, []);
