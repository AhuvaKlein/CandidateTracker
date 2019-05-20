# CandidateTracker

Assignment:
Create an application to track potential student/candidates for an upcoming course.

On the home page, display 4 links: Add Candidate, View Pending, View Confirmed
and View Declined. 

When the user clicks on the Add Candidate link, they should be taken to a page
that has a form where they can add the name, phone number and email of the
candidate. They should also be able to add notes (e.g. some details about the 
conversation with the candidate to help remember them in the future)

When they click on View Pending, they should be taken to a page that displays
a list of all the pending candidates. Next to each one, display a link
that allows the user to see that individual candidate. When they click on that link,
they should be taken to a page that displays all the information (including the 
notes) of that candidate along with two buttons: Confirm and Decline. When either
one of those buttons are clicked, via ajax, update the status of that candidate.

The View Confirmed and View Declined links should take the user to a page that 
shows the confirmed/declined candidates. 

For extra JS practice, add a "Toggle Notes"
button, that when clicked, shows/hides the notes column in the table.

Finally, in the navbar of the application, there should be three links: Pending, 
Confirmed and Declined. Next to each one of those links, display a number indicating
how many there are of each bunch. These numbers should also be updated when
confirming/declining via Ajax. Good luck!!
