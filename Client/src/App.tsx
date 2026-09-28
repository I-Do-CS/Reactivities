import axios from "axios";
import { useEffect, useState } from "react";
import { List, ListItem, ListItemText, Typography } from "@mui/material";

import type { Activity } from "./lib/types";

const App = () => {
  const [activities, setActivities] = useState<Activity[]>([]);
  useEffect(() => {
    const getActivities = async () => {
      const response = await axios.get<Activity[]>(
        "https://localhost:5001/api/activities"
      );
      setActivities(response.data);
    };

    getActivities();

    return () => {};
  }, []);

  return (
    <>
      <Typography variant="h3">Reactivities</Typography>
      <List>
        {activities.map((activity) => (
          <ListItem key={activity.id}>
            <ListItemText>{activity.title}</ListItemText>
          </ListItem>
        ))}
      </List>
    </>
  );
};

export default App;
