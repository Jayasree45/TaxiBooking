




function login($Email, $Password)
{
    $Password = sha1($Password);
    $result = mysqli_query($con, "select * from taxibooking1.customer WHERE EmailID='$username' AND Password='$Password'");
    while ($row = mysqli_fetch_array($result))
    {
        $success = true;
    }
    if ($success == true)
    {
        $_SESSION['EmailID'] = $Email;
        alert("Valid user")
        //redirect to home page
    }
    else
    {
        alert("InValid user")
       // echo '<div class="alert alert-danger">Oops! It looks like your username and/or password are incorrect. Please try again.</div>';
    }
}// END LOG