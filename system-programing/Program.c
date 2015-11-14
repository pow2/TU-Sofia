/*****************************************************************************
 ************* Designed by Plamen Prangov TU-Sofia 2014 **********************
 *****************************************************************************/


#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<pthread.h>

char word[128];

void *FSearch( void *file );

int main(int argc, char **argv)
{
    //not really needed, m is just shorter than argc
    int m = argc;
    //Show the syntax if there is no correct input
	if (argc == 1) 
		{printf("Syntax: Program word inputfile inputfile inputfile...\n");
		system("pause");
		return 0;
		}
		
	//Show the console input, not really needed. Just shiny
	for (int i = 1; i < m; ++i)
	{
		if (i == 1) {printf("Word: %s\n", argv[1]);}
		else {printf("File [%d]: %s\n", i-1, argv[i]);}
	};
	
	//array of threads
	 pthread_t t[m-2];
    // word will be global variable, since it will never change
	 strcpy(word, argv[1]);
 
	for (int i = 2; i < m; ++i)
	{	
       //create threads: i-2 because we started with i=2 and our th array has [0] - [m-2] threads
	   pthread_create(&t[i-2],NULL,FSearch,(void*)argv[i]);
	}
    //sync all threads
	for(int i = 0; i < m-2; ++i) pthread_join(t[i],NULL);
    
    //for test on windows with batch file
	system ("pause");
	
    return(0);
}

void *FSearch( void *file )
{
    /* string fn takes the file name */
    char *fn;
    fn = (char *) file;
    
    // standard variables for file file, line number, and word counter
    FILE *fp;
	int lineN = 1;
	
	// we will store the line in temporal line
	char tline[512];

    // open the file
    if((fp = fopen(fn, "r"))== NULL)
       {return(0);}
            
    while(fgets(tline, 512, fp) != NULL) 
        {
            // compare the strings   
            if((strstr(tline, word)) != NULL) {
            printf("File:%s Line:%d\n", fn, lineN);
		}
		//it count the lines
		lineN++;
	} 
	
	//close the file after we finish out work with it
	if(fp) {
		fclose(fp);
	}
   	return(0);
       
}